#!/usr/bin/env bash
set -euo pipefail

test_platform="${1:-editmode}"

UNITY_EXE="/mnt/c/Program Files/Unity/Hub/Editor/2022.3.62f2/Editor/Unity.exe"
PROJECT_PATH_LINUX="$CI_PROJECT_DIR"
RESULTS_DIR_LINUX="$CI_PROJECT_DIR/TestResults"
LOGS_DIR_LINUX="$CI_PROJECT_DIR/Logs"

mkdir -p "$RESULTS_DIR_LINUX" "$LOGS_DIR_LINUX"

PROJECT_PATH_WIN="$(wslpath -w "$PROJECT_PATH_LINUX")"
RESULTS_FILE_WIN="$(wslpath -w "$RESULTS_DIR_LINUX/${test_platform}-results.xml")"
LOG_FILE_WIN="$(wslpath -w "$LOGS_DIR_LINUX/${test_platform}.log")"

echo "Running Unity tests"
echo "Unity: $UNITY_EXE"
echo "Platform: $test_platform"
echo "Project (linux): $PROJECT_PATH_LINUX"
echo "Project (win): $PROJECT_PATH_WIN"

"$UNITY_EXE" \
  -batchmode \
  -accept-apiupdate \
  -projectPath "$PROJECT_PATH_WIN" \
  -runTests \
  -testPlatform "$test_platform" \
  -testResults "$RESULTS_FILE_WIN" \
  -logFile "$LOG_FILE_WIN"

exit_code=$?

echo "Unity exit code: $exit_code"
exit $exit_code