# Simple-web-api
Simple we api

## Step for build and run
Step 1 - Open Project ‘WebApiWpp’ using Microsoft Visual Studio (better to use visual studio 2015).

Step 2 - Install HttpClient library from NuGet

We are going to use HttpClient to consume the Web API REST Service, so we need to install this library from NuGet Package Manager .
 
What is HttpClient ?
 
HttpClient is base class which is responsible to send HTTP request and receive HTTP response resources i.e from REST services.
 
To install HttpClient, right click on Solution Explorer of created application and search for HttpClient, as shown in the following image.

![image](https://user-images.githubusercontent.com/39474112/40289915-b17b76e2-5cd8-11e8-92b3-42cd87a8d49a.png)

 
 
Now, click on "Install" button after choosing the appropriate version. It will get installed after taking few seconds, depending on your internet speed.
 
Step 3 - Install WebAPI.Client library from NuGet 
 
This package is used for formatting and content negotiation which provides support for System.Net.Http. To install, right click on Solution Explorer of created application and search for WebAPI.Client, as shown in following image.
 
  
 
Now, click on "Install" button after choosing the appropriate version. It will get installed after taking few seconds depending on your internet speed. We have installed necessary NuGet packages to consume Web API REST services in web application. I hope you have followed the same steps.

Step 3 – Execute all the required database script from ‘Evolent_Script’ folder(Attached).

Step 4 – Change the configuration file of project(Web.Config), provide valid database connection string.

<connectionStrings>
  <add name="dbConn" connectionString="server=localhost; uid=sa;  Password=caliber_09; database=DB1;"/>  
  </connectionStrings>
 
Step 5 – Build Solution.
Step 6 – Note the URL during running this API.
Step 7 – Run the ‘ConsumeWebApi’ solution (Windows form application project attached).
Step 8 – Change the Value of URL (which we note at the time of Web API running).
Step 9 – Now you can get list of Customer. You can perform add, Edit and delete operation inthe same.
