#!/bin/bash
set -e
curl -SL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 9.0
echo 'export PATH="$PATH:$HOME/.dotnet"' >> ~/.bashrc
export PATH="$PATH:$HOME/.dotnet"
dotnet --info
