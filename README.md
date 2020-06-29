# Warframe ReBa Farmer
This is an app for Warframe meant to help with more efficient Relic Farming and to give information about prime items that you get from Void fissures or trade at Baro's Kiosk.

## How it works
* Downloads WorldState data from Warframe to display Void Fissure and Baro timers.
* Downloads data about prime items from Warframe Market to display information in overlays.
* Makes screenshot of Warframe window and then uses Tesseract to perform OCR to get item names.
* When items are recognized it shows an overlay that contains information about Ducat Value, Platinum Prices, how many of that item are on the market and if item is vaulted.

&nbsp;

# Preview
<p float="left">
  <img src="https://i.imgur.com/KdruwRK.png" height="425" />
  <img src="https://i.imgur.com/tHVQB1p.png" height="425" /> 
  <img src="https://i.imgur.com/o0JFP3r.png" width="825" />
</p>

&nbsp;

# Limitations
Currently only confirmed working for 1920x1080 resolution (as that is what I play at).
Can be made to work with other resolutions with the help of your screenshots.

# Requirements
* .Net 4.6(+)
* Visual C++ 2015

# Installation
It is portable, no installation is required. Just run the exe.
