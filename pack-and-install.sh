#/usr/bin/bash
set -e
pkg=$(dotnet pack -v d --force | grep '.nupkg' | sed 's/^.*\Output files: \(.*nupkg\).*$/\1/')
dotnet new -i $pkg
