# SisoDb - Simple-Structure-Oriented-Db - a document-oriented db-provider for SQL Server 2005-2012, Express, LocalDb, SQL Azure & SQLCE4.

By using [SisoDb](http://sisodb.com) you get to store and retrieve complete POCO-graphs without having to specify:

* any mappings
* or extending any interfaces 
* or extending any base-classes

_There's no proxies_ etc. **It's just storage of your entities made simple**, and you add-on features as you need them. Like caching, dynamics, spatial etc.

You write your queries using lambda expressions and if you want, you can let SisoDb generate stored procedures from your lambdas. You can even write your lambdas using dynamic strings; so that they can be serialized and cross domains.

SisoDb is simple. **You activate the features you want**. If you want caching, then install that package. If you want spatial support, then install that package..., ..., ...

## What about SQL Express?
Yes it's supported. SisoDb is tested against SQL Server 2005, 2008 R2 and SQL2012 Express. You can of course use SQL Server 2012 Express LocalDb as well.

## A word about SQL Azure
Since v16.0.0 the generated schema is compatible with latest release of Azure. You can how-ever not make use of functions like Creating and Dropping databases, but it will support generating necessary tables etc.

## Getting started
Either you can read about it on [sisodb.com](http://sisodb.com/wiki/getting-started) or in the [Wiki](https://github.com/danielwertheim/SisoDb-Provider/wiki/getting-started). You can also have a look at this [short getting started screencast](http://vimeo.com/41374802).

## Management studio
In addition to the normal Management Studio there's also a web based tool for managing a SisoDb database, created by @mikaeleliasson. [More info here](https://github.com/MikaelEliasson/SisoDb.Management).

## NuGet
SisoDb is available via [NuGet (SisoDb)](http://nuget.org/packages?q=sisodb). You can also find some more info here: [http://sisodb.com/nuget](http://sisodb.com/nuget)

## More information
Follow [@danielwertheim](http://twitter.com/danielwertheim) and [@sisodb](http://twitter.com/sisodb)

For documentation, news etc, look under the wiki or goto: [http://sisodb.com](http://sisodb.com)

## License
License: [The MIT License (MIT)](http://www.opensource.org/licenses/mit-license.php)

## SemVer for versioning
SisoDb uses [SemVer](http://semver.org) for versioning.

## How-to Contribute
[Read instructions](https://github.com/danielwertheim/SisoDb-Provider/wiki/contribute) in the wiki.