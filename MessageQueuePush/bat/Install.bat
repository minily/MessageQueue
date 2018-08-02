%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe Zhongmubao.Push.WinServer.exe
Net Start ServiceTest
sc config ServiceTest start= auto