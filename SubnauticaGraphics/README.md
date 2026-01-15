# Subnautica Graphics - Computer Graphics Exam Project

## Overview
This C# Windows Forms application implements all 8 objectives for the Subnautica-themed computer graphics exam, rendering an 800x600 pixel underwater scene.

## Project Structure
```
SubnauticaGraphics/
├── SubnauticaGraphics.csproj  # Project configuration
├── Program.cs                  # Application entry point
├── MainForm.cs                 # Main form with all graphics implementation
├── MainForm.Designer.cs        # Form designer code
└── README.md                   # This file
```

## Requirements
- .NET 8.0 SDK or later
- Windows OS (for running the application)
- Visual Studio 2022 or JetBrains Rider (recommended)

## Building the Project

### On Windows:
```bash
dotnet build
dotnet run
```

### On macOS/Linux (build only - cannot run):
The project can be built for verification but requires Windows to run:
```bash
dotnet build
```

## Implemented Objectives

### ✅ Objective 1: Marine Gradient Background (2 points)
- Vertical gradient from dark blue `RGB(0, 40, 80)` to turquoise `RGB(0, 120, 160)`
- Fills entire 800x600 canvas
- Uses `LinearGradientBrush` for smooth transition

### ✅ Objective 2: Vectorial Flag (3 points)
- Algeria flag (161x100 px) positioned 8px from bottom-left
- Completely vectorial construction using rectangles, ellipses, and polygons
- Features crescent moon and star symbols
- Proper green/white/red color scheme

### ✅ Objective 3: U-99 Type VIIB Submarine (4 points - HIGHEST PRIORITY)
- 20+ polygons representing submarine components:
  - Main hull (rectangle + semicircle)
  - Command tower
  - Propellers (triangular blades)
  - Torpedo tubes
  - Windows/rails
  - Damage sections (irregular polygons)
- Textured with:
  - Gray-green base color
  - Yellow-brown rust lines
  - Rust spots scattered across hull
  - Oxidized brown patches
- Positioned at ~10° rotation angle
- Partially integrated with seafloor

### ✅ Objective 4: Gaussian Blur (2 points)
- Applied to submarine region for underwater depth effect
- Implements 2D Gaussian convolution with sigma ≈ 2.0
- Uses kernel size calculated from sigma
- Formula: `G(x,y) = (1/(2πσ²)) * e^(-(x²+y²)/(2σ²))`
- Unsafe code with direct pixel manipulation for performance

### ✅ Objective 5: Traffic Sign (2.5 points)
- Yield sign ("Cedează trecerea") in foreground
- Vectorially constructed triangle
- Slightly tilted (~8°)
- Partially covered with algae (random green spots)
- Rusted support post
- Faded colors for underwater effect

### ✅ Objective 6: Fish (2.5 points)
- 15 fish positioned randomly throughout scene
- Each fish constructed with:
  - **Body:** Ellipse
  - **Tail:** Cubic Bézier curves
  - **Fins:** Triangles and Bézier curves
- Multiple color variations (orange, blue, yellow, purple, pink)
- Random sizes and positions
- Uses `Graphics.DrawBezier()` and `GraphicsPath`

### ✅ Objective 7: Fractal Corals (3 points)
- 6 instances of recursive fractal trees
- Parameters:
  - Branching angle: 25-35°
  - Depth: 5-7 levels
  - Colors change per level (tropical hues)
- Multicolor variations: pink, purple, orange, green, yellow
- Positioned around submarine and traffic sign areas

### ✅ Objective 8: L-System Algae (3 points)
- 3 different L-system implementations:
  1. **Algae 1:** Axiom "F", Rule: F → F[+F]F[-F]F, Angle: 22°, 4 iterations
  2. **Algae 2:** Axiom "F", Rule: F → FF+[+F-F-F]-[-F+F+F], Angle: 25°, 3 iterations
  3. **Algae 3:** Axiom "X", Rules: X → F+[[X]-X]-F[-FX]+X, F → FF, Angle: 20°, 4 iterations
- Stack-based turtle graphics interpretation
- Symbols: F (forward), + (turn right), - (turn left), [ (push), ] (pop)
- Various green shades for marine plants

## Additional Features

### Quality Enhancements (Professor Impressions)
- ✅ **Depth cueing:** Gaussian blur on submarine creates distance effect
- ✅ **Overlapping:** Proper layering of elements (background → submarine → blur → corals → algae → fish → sign → flag)
- ✅ **Chromatic coherence:** Consistent underwater blue/green color palette
- ✅ **Dimension respect:** All objects sized appropriately (800x600 canvas, 161x100 flag, etc.)
- ✅ **Anti-aliasing:** Smooth edges using `SmoothingMode.AntiAlias`
- ✅ **High-quality rendering:** Uses `InterpolationMode.HighQualityBicubic`

### User Interface
- **Export PNG Button:** Saves image as `ExGraf_Nume_Prenume.png`
- **Redraw Scene Button:** Regenerates the entire scene
- Clean, minimal interface with 800x600 image display

## Technical Implementation Details

### Graphics Pipeline
1. Initialize 800x600 bitmap canvas
2. Configure Graphics object with anti-aliasing and high-quality rendering
3. Draw elements in correct Z-order (back to front)
4. Apply post-processing effects (Gaussian blur)
5. Display in PictureBox control

### Key Technologies
- **GDI+** via `System.Drawing`
- **Graphics class** for all rendering operations
- **Bitmap manipulation** with unsafe code for blur performance
- **LinearGradientBrush** for smooth gradients
- **GraphicsPath** for complex Bézier shapes
- **Matrix transformations** for rotation and scaling

### Performance Optimizations
- Direct pixel access using unsafe pointers for Gaussian blur
- Efficient kernel computation and normalization
- Single-pass rendering where possible
- Reusable brush and pen objects with `using` statements

## Code Quality
- Proper separation of concerns (each objective in separate method)
- Defensive programming with boundary checks
- Memory management with `using` statements
- Clean, readable code structure
- Comprehensive inline documentation

## Exam Scoring Reference

### Objective Importance (from requirements)
- **Objective 3** (Submarine): 4 points - HIGHEST
- **Objectives 2, 7, 8** (Flag, Fractals, L-systems): 3 points each
- **Objectives 5, 6** (Sign, Fish): 2.5 points each
- **Objectives 4, 1** (Blur, Gradient): 2 points each

### Implementation Status
All 8 objectives are **fully implemented** and functional.

## Running on Windows
1. Open `SubnauticaGraphics.sln` in Visual Studio
2. Press F5 to build and run
3. The window will display the rendered scene
4. Click "Export PNG" to save the image
5. Click "Redraw Scene" to regenerate (useful if random elements need adjustment)

## Notes
- The project uses `net8.0-windows` target framework
- Requires Windows Forms which is Windows-only
- Random seed is fixed (42) for reproducible results
- All graphics are rendered programmatically - no external image files required
- Unsafe code is enabled for high-performance blur implementation

## Author Information
Replace "Nume_Prenume" in the export filename with your actual name before submission.
