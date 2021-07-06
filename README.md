# GTFS Engine

## Français ##  
La General Transit Feed Specification ([GTFS](https://developers.google.com/transit/gtfs/reference?hl=fr)) est une spécification de données qui permet aux agences de transport en commun de publier leurs données de transport dans un format pouvant être utilisé par une grande variété d'applications logicielles. Aujourd'hui, le format de données GTFS est utilisé par des milliers de fournisseurs de transports publics.  

### Utilisation
Avec un fichier zip qui contient tous les fichiers `txt`, la librairie permet de charger tout en mémoire avec les relations comme indiquées :  
<p align="center"><kbd><img src="https://i.ibb.co/cL0BC4X/GTFSdb.png" height="450"></kbd></p>

### Chargement  
Fichier zip :
```csharp
DataEngine engineData = new DataEngine();
engineData.LoadDatasByZip(File.OpenRead(pathZip));
```

Charger un fichier txt "seul" :
```csharp
string path = "c:\chemin\chemin\shapes.txt";
DataEngine dataEngine = new DataEngine();
dataEngine.LoadData<Shapes>(File.OpenRead(path));
```

### Exploitation
Il est possible de naviguer entre les propriétés, commme par exemple :
```csharp
Trips trip = engineData.Gtfs.GetTrip("idTrip");
// Route lié à ce trip.
Routes routeLieAuTrip = trip.RoutesFk;
// Tous les stopTimes pour ce trip.
IEnumerable<StopTimes> stopTimes = trip.StopTimesCollection;
```
------------
## English ##  
The General Transit Feed Specification ([GTFS](https://developers.google.com/transit/gtfs/reference?hl=en)) is a data specification that allows public transit agencies to publish their transit data in a format that can be consumed by a wide variety of software applications.Today, the GTFS data format is used by thousands of public transport providers.  

## Usage
With a zip file that contains all the 'txt' files, the library allows you to load everything in memory with the relationships as indicated :
<p align="center"><kbd><img src="https://i.ibb.co/cL0BC4X/GTFSdb.png" height="450"></kbd></p>

### Loading
Zip file :
```csharp
DataEngine engineData = new DataEngine();
engineData.LoadDatasByZip(File.OpenRead(pathZip));
```

Load a txt file "alone" :
```csharp
string path = "c:\path\path\shapes.txt";
DataEngine dataEngine = new DataEngine();
dataEngine.LoadData<Shapes>(File.OpenRead(path));
