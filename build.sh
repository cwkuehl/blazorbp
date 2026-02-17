#! /bin/sh

cd /home/wolfgang/cs/blazorbp
dotnet publish BlazorBp
cd /home/wolfgang/cs/blazorbp/BlazorBp/bin/Release/net9.0/publish/
dotnet BlazorBp.dll
