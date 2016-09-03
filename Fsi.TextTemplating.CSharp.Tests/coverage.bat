set OpenCover="%USERPROFILE%\.nuget\packages\OpenCover\4.6.519\tools\OpenCover.Console.exe"
set ReportGenerator="%USERPROFILE%\.nuget\packages\ReportGenerator\2.4.5\tools\ReportGenerator.exe"
set dotnetCLI="%ProgramW6432%\dotnet\dotnet.exe"
set CoverageDir="%~dp0Coverage"
set CoverageResult="%~dp0Coverage\coverage.xml"
set ResultHtm="%~dp0Coverage\index.htm"
%OpenCover% -target:%dotnetCLI% -targetargs:"test %~dp0 -f net46" -output:%CoverageResult% -register:user -filter:+[Fsi.TextTemplating.CSharp]* -filter:+[Fsi.TextTemplating.CSharp.Tests]*
%ReportGenerator% -reports:%CoverageResult% -targetdir:%CoverageDir% -sourcedirs:"%~dp0;%~dp0\..\Fsi.TextTemplating.CSharp\"
%ResultHtm%