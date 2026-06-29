# SSLCertificateTrakcer
## Introduction
<img width="1129" height="684" alt="image of SSL Certificate Application UI with different example hosts to show different states of the application" src="https://github.com/user-attachments/assets/ee2a14ee-d474-4b9f-982f-b5463ed323d1" />

### Description:
This is a SSL Certificate Tracker application made using .Net 10 and Winforms (my first every .Net application). It allows a user to track different hosts and display meaningful data to the user about the entered hosts SSL Certificate. It shows a status of OK (Days left: Anything 30 days or greater), Expiring Soon (Days Left: 29-0), Expired (Days Left: anything negative) so you can easily keep track of hosts in one place. It was made to 

## Prerequisites
Before getting started make sure you meet the following:


**Operating System:** **Windows 10** or 11


**Software:** **.Net SDK 10.0** or higher

**Optional:** Git for windows

The official runtime can be downloaded from microsoft directly here: https://dotnet.microsoft.com/en-us/download/dotnet/10.0

Git for Windows can be installed from here: https://git-scm.com/

## Build and Compile
Follow these steps to download the source code and compile it to the Release build of the Application:

### 1. Clone the repository (With Git)
Launch Git bash and enter in the following when in desired directory:
```
git clone https://github.com/SnakeZx/SSLCertificateTracker.git
cd SSLCertificateTracker
```
### 1. Clone the repository (No Git)
1. Press the green **Code** buttton at the top of this page.
2. Press the **Download Zip** at the bottom of menu.
3. Extract the zip file to desired folder location.

### 2. Open CMD or Terminal
Nagivate to the new extracted or cloned folder directory like so:

```
cd "C:\EXTRACTED FOLDER PATH HERE\"
```

### 3. Compile Into Standalone .EXE
Run this in CMD or Terminal command to bundle all code and dependencies into one single .exe file:

```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

### 4. Locate Compiled Files Folder
1. Locate newly made "/publish" folder in the project directory.
2. Once inside locate the single executable (.EXE) file.
3. Double-click on the .EXE to run the compiled application.
