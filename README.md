# SSLCertificateTrakcer
## Introduction
<img width="1129" height="684" alt="image" src="https://github.com/user-attachments/assets/ee2a14ee-d474-4b9f-982f-b5463ed323d1" />

This is a SSL Certificate Tracker application made using .Net 10 and Winforms. It allows a user to track different hosts and display meaningful data to the user about the entered hosts SSL Certificate. It shows a status of OK (Days left: Anything 30 days or greater), Expiring Soon (Days Left: 29-0), Expired (Days Left: anything negative) so you can easily keep track of hosts in one place. It was made to 

## Prerequisites
Before getting started make sure you meet the following:


**Operating System:** **Windows 10** or 11


**Software**: **.Net Desktop Runtime 10.0** or higher

The official runtime can be downloaded from microsoft directly here: https://dotnet.microsoft.com/en-us/download/dotnet/10.0

## Build and Compile
Follow these steps to download the source code and compile it to the Release build of the Application:

### 1. Clone the repository
Open Terminal or Command Prompt and enter in the following:
```
git clone https://github.com/SnakeZx/SSLCertificateTrakcer.git
```
```
cd SSLCertificateTracker
```
### 2. Compile Into Standalone .EXE
Run this command to bundle all code and dependencies into one single .exe file:

```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ./publish
```

### 3. Locate Compiled Files Folder
1. Locate newly made "/publish" folder in the project directory.
2. Once inside locate the single executable (.EXE) file.
3. Double-click on the .EXE to run the compiled application.
