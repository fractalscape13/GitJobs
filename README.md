# GitJobs

#### _Web application for finding and saving job listings with GitHub's Jobs API_

#### By: **Benjamin Thom, Joseph Wangemann, Zakkrey Short, Hristo Dzhambov**, April 7-9, 2020

## Description

_A C# MVC application that allows job seekers to search, save, and organize job opportunities utilizing the GitHub Jobs API, ASP.NET Core Identity to manage users, passwords, and profile information and a SQL database for storing data._

## Specification user stories:
| Specification | Example Input | Example Output |
| ------------- |:-------------:| -------------------:|
| User visit GitJobs home page and the program displays welcome message along with buttons to **search jobs** and **view account**| User types a http://localhost:5000/ into their web browser | http://localhost:5000/ |
| User clicks **search jobs** button and the application displays a jobs homepage with a search jobs input form on the left and a list of jobs that meet the search requirements on the right| User clicks **search jobs** button | http://localhost:5000/Jobs |
| User submits search and clicks the **add this job** button on a job post from the list of queried results | User submits search and clicks the **add this job** button | http://localhost:5000/Jobs/Create |
| If the user is not logged in the application will redirect to the account homepage where they can click the **register** button or enter their user details and click the **log in** button | N/A | http://localhost:5000/Account |
| User clicks the **register** button and the application displays a registration form with inputs for username, password, confirm password, and a **register** button | User clicks the **register** button | http://localhost:5000/Account/Register |
| User completes a form and clicks the **register** button and is redirected back to the account homepage and the application displays a welcome message along with three buttons (**see all jobs**, **see saved jobs**, and **log out**) | User clicks the **register** button | http://localhost:5000/Account |
| If a user clicks **log out** button, the user will be logged out of their account and redirected to the account homepage| User clicks **log out** button | http://localhost:5000/Account |
| If a user clicks **see all jobs** button, the application will redirect to the jobs homepage where they can now successfully save jobs to their account | User clicks **see all jobs** button | http://localhost:5000/Jobs |
| If a logged in user clicks **add this job** button, app will navigate to confirmation form where a user can add notes regarding application status and priority level  | User clicks **add this job** button | http://localhost:5000/Jobs/Create |
| If a user clicks **see saved jobs** button, the application will display a list of jobs the user has saved with the following details (title, location, application status, and a view posting link) as well as buttons to **delete this job** and **edit this job** | User clicks **see saved jobs** button | http://localhost:5000/Account/SavedJobs |
| User clicks the **edit this job** button and the application displays a form with job details based on its job id and the ability to update the job's title, location, url, status, priority, and a **save changes** button | User clicks the **edit this job** button | http://localhost:5000/Account/Edit |
| User clicks **delete this job** button and is redirected to a delete confirmation page and the application displays the title and location of the job based on the job id, a **confirm delete** button, and a **back to saved jobs** button | User clicks **delete this job** button | http://localhost:5000/Account/Delete/ |

## Setup/Installation Requirements

### Install .NET Core

#### on macOS:
* _[Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) to download a .NET Core SDK from Microsoft Corp._
* _Open the file (this will launch an installer which will walk you through installation steps. Use the default settings the installer suggests.)_

#### on Windows:
* _[Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp._
* _Open the .exe file and follow the steps provided by the installer for your OS._

#### Install dotnet script
_Enter the command ``dotnet tool install -g dotnet-script`` in Terminal (macOS) or PowerShell (Windows)._

### Install MySQL

#### on macOS:
_Download the MySQL Community Server DMG File [here](https://dev.mysql.com/downloads/file/?id=484914). Follow along with the installer until you reach the configuration page. Once you've reached Configuration, set the following options (or user default if not specified):_
* use legacy password encryption
* set password (and change the password field in appsettings.json file of this repository to match your password)
* click finish
* open Terminal and enter the command ``echo 'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile`` if using Git Bash.
* Verify MySQL installation by opening Terminal and entering the command ``mysql -uroot -p{your password here, omitted brackets}``. If you gain access to the MySQL command line, installation is complete. An error (e.g., -bash: mysql: command not found) indicates something went wrong.

#### on Windows:
_Download the MySQL Web Installer [here](https://dev.mysql.com/downloads/file/?id=484919) and follow along with the installer. Click "Yes" if prompted to update, and accept license terms._
* Choose Custom setup type
* When prompted to Select Products and Features, choose the following: MySQL Server (Will be under MySQL Servers) and MySQL Workbench (Will be under Applications)
* Select Next, then Execute. Wait for download and installation (can take a few minutes)
* Advance through Configuration as follows:
  - High Availability set to Standalone.
  - Defaults are OK under Type and Networking.
  - Authentication Method set to Use Legacy Authentication Method.
  - Set password to epicodus. You can use your own if you want but epicodus will be assumed in the lessons.
  - Unselect Configure MySQL Server as a Windows Service.
* Complete installation process

_Add the MySQL environment variable to the System PATH. Instructions for Windows 10:_
* Open the Control Panel and visit _System > Advanced System Settings > Environment Variables..._
* Select _PATH..._, click _Edit..._, then _Add_.
* Add the exact location of your MySQL installation and click _OK_. (This location is likely C:\Program Files\MySQL\MySQL Server 8.0\bin, but may differ depending on your specific installation.)
* Verify installation by opening Windows PowerShell and entering the command ``mysql -uroot -p{your password here, omitted brackets}``. It's working correctly if you gain access to the MySQL command line. Exit MySQL by entering the command ``exit``.

### Clone this repository

_Enter the following commands in Terminal (macOS) or PowerShell (Windows):_
* ``cd desktop``
* ``git clone https://github.com/fractalscape13/GitJobs``
* ``cd GitJobs/GitJobs``
* ``dotnet ef database update``
* ``dotnet run`` or ``dotnet watch run``


_Confirm that you have navigated to the GitJobs directory (e.g., by entering the command_ ``pwd`` _in Terminal)._

## Run this MVC application in another Terminal or PowerShell window

_Run this MVC application by entering the following command in Terminal (macOS) or PowerShell (Windows) at the root of the GitJobs directory:_
* ``dotnet run`` or ``dotnet watch run``

_To view/edit the source code of this application, open the contents of the GitJobs directory in a text editor or IDE of your choice (e.g., to open all contents of the directory in Visual Studio Code on macOS, enter the command_ ``code .`` _in Terminal at the root of the GitJobs directory)._

## Routes

ACCOUNT
```
GET /account
GET /account/register
POST /account/register
GET /account/login
POST /account/login
GET /account/savedjobs
DELETE /account/delete/{jobId}
```

JOBS
```
GET /jobs
GET /jobs/search
```

POSITIONS 
```
GET /positions.json
GET /positions/ID.json
```

## Technologies Used

* Git
* C#
* .NET Core 2.2
* MySQL 8.0.15
* ASP.NET Core MVC 2.2
* Entity Framework Core 2.2
* Identity
* RestSharp version 106.6.10
* Newtonsoft.Json version 12.0.2
* GitHub Jobs API (https://jobs.github.com/api)

## License

Licensed under the MIT license.

&copy; 2020 - Benjamin Thom, Joseph Wangemann, Zakkrey Short, Hristo Dzhambov