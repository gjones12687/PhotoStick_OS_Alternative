# PhotoStick OpenSource Alternative
This solution provides similar functionality to the windows part of the advertised Photostick.

Requirements: 
+.NET Framework 4.0

Current Functionality: 
+Finds all images of types PNG, JPEG, TIFF, RAW, BMP and SVG based on extension  
+Finds all Videos of types WVM, MPEG, MP4, AVI based on extension  
+Removes byte-equivalent duplicates of images. This means it's unlikely to find duplicates that are of a different file type, but any of the same image in the same file type should be found

TODO:
+Move to C++ for cross-platform capabilities.
+Additional duplication methods - machine learning (Lightweight, accurate algorithm needed to run on as much hardware as possible)
+Duplicate detection methods for videos - random frame check, machine learning

