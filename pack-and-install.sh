#!/usr/bin/bash

set -e

echo "Packing..."
pkg=$(dotnet pack -v d --force | grep 'file.*nupkg' | sed -E 's_^.*(Output file \"|Output files: )(.*nupkg).*$_\2_')

echo "Installing..."
dotnet new -i $pkg | grep 'Template\|---\|aksapi'

echo "Complete ✔️"
