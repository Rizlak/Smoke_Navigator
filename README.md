NUnit is a free, open-source tool for .NET that is developed as a framework which can help automate unit testing. (The same unit test framework was already available for Java and was named jUnit.) NUnit can be downloaded directly from

https://github.com/nunit/nunit/releases/download/3.0.1/NUnit.3.0.1.msi

or

http://www.nunit.org/download.html

and .NET Framework is required

Installation and using - NUnit

After downloading the NUnit from either of the above download pages, run the installation program, NUnit-XXX.msi. At the time of this writing, the current most stable version of NUnit is 2.6.4 and the setup file name is NUnit-2.6.4.msi. This setup will install the required libraries.
NUnit provides two utilities which can be used for running automated tests:
nunit-gui.exe, a GUI tool which I most commonly use, and nunit-console.exe, which is a console program

Once you have installed NUnit you can test if the installation has gone through properly using the nunit-gui.exe tool. This can be run from Start Menu --> Programs --> Nunit --> NUnit GUI. 
After opening the tool, click on the File --> Open and open the nunit.tests.dll from the smoke_navigator\smoke_navigator\bin\Debug folder. When the smoke_navigator.DLL is chosen, NUnit-GUI shows all the unit test code written for the particular DLL using the NUnit 
framework. Now you can select which test/tests you want and click Run button. When button Run is clicked, it will show the results as follows.

Passed Test - Green color

Failed Test - Red color

Ignored Test - Yellow color
