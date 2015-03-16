Requirements to build Rock and Roll.

# Introduction #

You will need the following to download, and compile Rock and Roll:

  * Subversion Client
  * Visual Studio 2008
  * Nini (Will be removed in future versions)

# Details #

For the Subversion client, I recommend [TortoiseSVN](http://tortoisesvn.tigris.org/).

For the version of Visual Studio 2008, I have developed it in Professional Edition, but any versions less than Professional should be able to compile the code (such as Express edition).

The library uses the Client Framework subset version of .NET 3.5.  If you are stuck on Visual Studio 2005, you will need to downgrade the project to 2005's project format, and rewrite any bits of the project that use LINQ (there shouldn't be that many).

For Nini, grab the source off the project's homepage. Extract the project's files to a directory called Nini in the same directory that the folder where you checked out Rock and Roll's files to. Alternatively, wait until I remove the dependency on Nini.