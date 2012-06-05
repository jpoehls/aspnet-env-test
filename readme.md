## What is this?

This is an experiment to test how IIS handles environment variables in ASP.NET processes.

The [Twelve-Factor App](http://www.12factor.net/config) recommends storing _deployment specific_
configuration in environment variables. This is not a common practice in the .NET world.

The goal of this experiment is to show that this strategy can be easily used in ASP.NET hosted on IIS.

## How it works

IIS doesn't provide a way to set environment variables for individual sites so we are
bootstrapping the environment on `Application_Start` in `Global.asax.cs`.

This kind of bootstrapping could be integrated into an app transparently by bundling
the bootstrapping logic in a NuGet package that uses WebActivator to run on startup.

`Default.aspx.cs` echos the environment variable set on startup.

A configuration file that stores the environment variables is stored alongside the
app's IIS website directory.

```
c:\inetpub\wwwroot\EnvTestA   <-- IIS website dir
c:\inetpub\wwwroot\EnvTestA.envConfig.txt  <-- environment configuration file
```

## Results

So far this experiment has shown that the process environment variables are isolated between the **AppPools**.

If both sites share an AppPool then the environment variables are shared between them.

Bottom line? Keep your apps in separate pools and you can use environment variables for configuration.

## DIY

The IIS setup for this test is as follows:

1. 2 IIS sites (A & B)
2. Each in their own AppPool
3. Each AppPool is "Integrated" and on .NET 4.0
4. Each site is in its own directory under `c:\inetpub\wwwroot` (i.e. `.\EnvTestA` and `.\EnvTestB`)
5. There are environment config files along side the IIS site folder.  
   (i.e. `c:\inetpub\wwwroot\EnvTestA.envConfig.txt` for the `c:\inetpub\wwwroot\EnvTestA` site.)

Build the web app.

Use the `./deploy.ps1` script to copy the website to the IIS folders and create the `*.envConfig.txt` files.