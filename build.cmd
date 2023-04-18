@echo off
pushd Client
dotnet publish -c Release
popd

pushd Server
dotnet publish -c Release
popd

rmdir /s /q dist
mkdir dist

copy /y fxmanifest.lua dist
xcopy /y /e Client\bin\Release\net452\publish\ dist\Client\
xcopy /y /e Server\bin\Release\netstandard2.0\publish\ dist\Server\
xcopy /y /e static\ dist\static\

rmdir /s /q Client\bin\
rmdir /s /q Client\obj\

rmdir /s /q Server\bin\
rmdir /s /q Server\obj\