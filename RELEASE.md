# Release Notes
## 2.0.0
* This release contains a reorganisation of classes and methods to better align with the ICAO specification.  Be advised that there are many breaking changes that come with this version
* Updgraded from .Net 5.0 to .Net 7.0
* Removed MwCavok as CAVOK is now supported in the MwVisibilityGroup class
* Removed RwRainEnded due to incorrect implementation
* Removed MwWindVariation as wind variation is now supported in MwSurfaceWindGroup class
* Removed RwRainBegan due to incorrect implementation
* Removed MwStatuteMiles as SM is now supported in MwVisibilityGroup class
* Removed MwTemp due to incorrect implementation
* Renamed GwSurfaceTowerVisibility to RwSurfaceTowerVisibilityGroup
* Renamed GwTornadic to RwTornadicGroup
* Renamed GwVariableCeiling to RwVariableCeilingGroup
* Renamed GwPeakWind to RwPeakWindGroup
* Renamed GwWindShift to RwWindShiftGroup
* Renamed MwRunwayStateGroup to MwStateOfRunway
* Renamed MwSurfaceWind to MwSurfaceWindGroup
* Renamed MwVisibility to MwVisibilityGroup
* Added class MwWindShearGroup
* Added class RwSurfaceTowerVisibilityGroup
* WeatherType enum now supports Ice Crystals and Spray
* CloudType enum now refers to Cumulonimbus/Towering Cumulus types of cloud
* Cloud enum now represents Scattered, Broken, Few and others