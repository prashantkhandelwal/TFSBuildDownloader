TFS Build Downloader
==================
![Build status](https://ci.appveyor.com/api/projects/status/4asmh163dcioge8r?svg=true)

Console application which allows you to download build from Visual Studio online (TFS Online)

List All The Builds

```ps
C:\> TFSBuildDownloader.exe -n prashant@hotmail.com -p <Password> -c <https://foobar.visualstudio.com/DefaultCollection> -t Weblog
```

Use the build number from the list returned by executing the above command and then add ```-d``` in the end to download the zip file.

```ps
C:\> TFSBuildDownloader.exe -n prashant@hotmail.com -p <Password> -c <https://foobar.visualstudio.com/DefaultCollection> -t Weblog -b Weblog-Build_20141113.2 -o D:\ -d
```