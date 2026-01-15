# Examen - Computer Graphics Requirements

## Main Task
Create an 800 x 600 px image following the "Subnautica" theme module.

---

## Objectives

### Obiectiv 1 (90%)
**Marine gradient background with material filter**

**Hint:**
- `RGB(0, 40, 80)` (albastru închis)
- `RGB(0, 120, 160)` (turcoaz)

---

### Obiectiv 2 (70%)
**Create an 8px left margin from the bottom, displaying the (x) dimension flag (161 x 100 px) constructed vectorially** (obiectul 2)

---

### Obiectiv 3 (0%)
**Print a list of minimum 20 polygons with (RTS) and texture, representing with accuracy the largest epaulet of a German submarine (preferably U-99 Type VIIB) of Captain Otto Kretschmer** (obiectul 3 cu dimensiune aproximativă).

**Hint:**
- **corp principal** (dreptunghi + semicercr)
- **turn de comandă**
- **elice** (3-4 triunghiuri)
- **tuburi torpile**
- **gard / ferestre**
- **bucați rupte** (poligoane neregulate)
- **Textură gălbuie de linii** + **pete rugină, culori:** gri-verde, maro oxidat
- **Poziție:** fundal, uşor rotit (ex: -10°), parțial înegrat în nisip

**Additional Information - U-99 Type VIIB Submarine:**
- **Displacement:** 753 tonnes (surface), 857 tonnes (submerged)
- **Length:** 66.50 m total, 48.80 m pressure hull
- **Beam:** 6.20 m
- **Height:** 9.50 m
- **Draught:** 4.74 m
- **Speed:** 17.9 knots (surface), 8 knots (submerged)
- **Armament:** 5 torpedo tubes (4 bow, 1 stern), 14 torpedoes, 1x 8.8 cm naval gun, 1x 2 cm anti-aircraft gun
- **Crew:** 44-60 personnel
- **Commander:** Korvettenkapitän Otto Kretschmer
- **Service:** Nazi Germany's Kriegsmarine during World War II

---

### Obiectiv 4 (0%)
**Construct a Gaussian blur for zone obiectului 3 to accent the "sub apă" effect of the epaulet**

**Hint:**
- **kernel:** 5×5 sau 7×7
- **sigma ≈ 2.0**

**Gaussian Blur Theory:**
- Gaussian blur applies a Gaussian function to convolve the image
- Formula (1D): `G(x) = (1/√(2πσ²)) * e^(-x²/(2σ²))`
- Formula (2D): `G(x,y) = (1/(2πσ²)) * e^(-(x²+y²)/(2σ²))`
- σ (sigma) is the standard deviation controlling the blur amount
- Larger sigma = more blur
- Typically use kernel size of ⌈6σ⌉ × ⌈6σ⌉
- Pixels beyond 3σ distance have negligible influence
- Gaussian blur is a low-pass filter reducing high-frequency components
- Can be applied as separable filter (horizontal then vertical) for efficiency

---

### Obiectiv 5 (0%)
**In the foreground (obiectul 4), a circulation indicator with significance (y) (s-a scufundat și el)** **(construiț vectorial)**

**Hint:**
- **uşor înclinat**
- **parțial acoperit de alge**
- **culori spălate**
- **suport ruginit**

---

### Obiectiv 6 (0%)
**Zone 5 will contain at least 13 fish (utilized) positioned randomly, constructed through combinations of ellipses and Bezier curves**

**Hint:**
- **Construcție:** corp: **elipsă**, coadă: **Bezier cubic**, aripioare: **Bezier + triunghiuri**
- **Pozitionare:** random.

---

### Obiectiv 7 (0%)
**Around zones 3 and 4, construct at least 6 instances of a "coral fractalic, multicolor" function**

**Hint:**
- **Fractal Tree** (recursiv)
- **ramificare la 25-35°**
- **adâncime:** 5-7
- **culori schimbate pe nivel**
- **Fractal de tip Koch adaptat**
- **nu clasic alb**
- **culori tropicale**

**L-System Fractal Tree Information:**
- L-systems are formal grammars used to model plant growth and fractals
- Developed by Aristid Lindenmayer in 1968
- **Binary Tree Example:**
  - Variables: 0, 1
  - Constants: "[", "]"
  - Axiom: 0
  - Rules: (1 → 11), (0 → 1[0]0)
- **Turtle Graphics Interpretation:**
  - 0: draw line segment ending in leaf
  - 1: draw line segment
  - [: push position/angle, turn left 45°
  - ]: pop position/angle, turn right 45°
- Uses LIFO stack for position/angle storage
- Produces self-similar recursive structures
- Can create complex branching patterns through simple rules

---

### Obiectiv 8 (0%)
**Add at least 2 models of L-system that simulate algae and marine plants**

**Hint:**
- **Axiom:** F
- **Rules:** F = F[+F]+F[-F]F
- **Angle:** 22°
- **Iterations:** 4-5

**L-System Algae Example (Lindenmayer's Original):**
- Variables: A, B
- Axiom: A
- Rules: (A → AB), (B → A)
- Produces Fibonacci word sequence
- String length follows Fibonacci numbers
- Ratio of A to B converges to golden ratio

---

## Anexa 1: Lista steagurilor agregate pentru examen

| # | Country | Flag |
|---|---------|------|
| 1 | Algeria | 🇩🇿 |
| 2 | Antigua and Barbuda | 🇦🇬 |
| 3 | Argentina | 🇦🇷 |
| 4 | Australia | 🇦🇺 |
| 5 | Azerbaijan | 🇦🇿 |
| 6 | Bosnia and Herzegovina | 🇧🇦 |
| 7 | Burkina Faso | 🇧🇫 |
| 8 | Burundi | 🇧🇮 |
| 9 | Cabo Verde | 🇨🇻 |
| 10 | Cameroon | 🇨🇲 |
| 11 | CAR | 🇨🇫 |
| 12 | Chile | 🇨🇱 |
| 13 | China | 🇨🇳 |
| 14 | Comoros | 🇰🇲 |
| 15 | Cuba | 🇨🇺 |
| 16 | Djibouti | 🇩🇯 |
| 17 | DPRK | 🇰🇵 |
| 18 | DRC | 🇨🇩 |
| 19 | Georgia | 🇬🇪 |
| 20 | Ghana | 🇬🇭 |
| 21 | Greece | 🇬🇷 |
| 22 | Guinea Bissau | 🇬🇼 |
| 23 | Honduras | 🇭🇳 |
| 24 | India | 🇮🇳 |
| 25 | Jordan | 🇯🇴 |
| 26 | Liberia | 🇱🇷 |
| 27 | Lybia | 🇱🇾 |
| 28 | Malaysia | 🇲🇾 |
| 29 | Maldive | 🇲🇻 |
| 30 | Marshall Islands | 🇲🇭 |
| 31 | Mauritania | 🇲🇷 |
| 32 | Micronesia | 🇫🇲 |
| 33 | Morocco | 🇲🇦 |
| 34 | Myanmar | 🇲🇲 |
| 35 | Namibia | 🇳🇦 |
| 36 | Nauru | 🇳🇷 |
| 37 | New Zeeland | 🇳🇿 |
| 38 | North Macedonia | 🇲🇰 |
| 39 | Panama | 🇵🇦 |
| 40 | Rwanda | 🇷🇼 |
| 41 | Saint Kitts and Nevis | 🇰🇳 |
| 42 | Samoa | 🇼🇸 |
| 43 | Sao Tome and Principe | 🇸🇹 |
| 44 | Senegal | 🇸🇳 |
| 45 | Singapore | 🇸🇬 |
| 46 | Solomon Islands | 🇸🇧 |
| 47 | Somalia | 🇸🇴 |
| 48 | South Africa | 🇿🇦 |
| 49 | South Sudan | 🇸🇸 |
| 50 | St. Vincent Grenadines | 🇻🇨 |
| 51 | Suriname | 🇸🇷 |
| 52 | Syria | 🇸🇾 |
| 53 | Timor-Leste | 🇹🇱 |
| 54 | Togo | 🇹🇬 |
| 55 | Tunisia | 🇹🇳 |
| 56 | Turcia | 🇹🇷 |
| 57 | Tovalu | 🇹🇻 |
| 58 | Uruguay | 🇺🇾 |
| 59 | Vietnam | 🇻🇳 |
| 60 | Palpatine's First Galactic Empire | ⚫ (Imperial Symbol) |

---

## Anexa 2: Lista indicatoarelor de circulație agregate pentru examen

| # | Indicator |
|---|-----------|
| 1 | Cedează trecerea |
| 2 | Oprire (Stop) |
| 3 | Drum cu prioritate |
| 4 | Prioritate pentru circulația din sens invers |
| 5 | Prioritate față de circulația din sens invers |
| 6 | Accesul interzis autovehiculelor cu excepția motocicletelor fără ataș |
| 7 | Accesul interzis vehiculelor destinate transportului de mărfuri |
| 8 | Accesul interzis pietonilor |
| 9 | Drum cu denivelări |
| 10 | Accesul interzis vehiculelor care transportă mărfuri periculoase |
| 11 | Direcția obligatorie pentru vehiculele care transportă mărfuri periculoase |
| 12 | Intersecție cu sens giratoriu |
| 13 | Aeroport |
| 14 | Presemnalizare intersecție cu sens giratoriu |
| 15 | Trecere la nivel cu o cale ferată cu bariere sau semibariere |

---

## Detalii suplimentare care impresionează profesorul

✅ **Depthcueing** (obiecte mai departe = mai șterse)  
✅ **Overlapping**  
✅ **Coerență cromatică**  
✅ **Respectarea dimensiunilor**  
✅ **Nu plângeți zgomotos, (deranjați colegii)**

---

## Final

**Salvați imaginea cu numele:** `ExGraf_Nume_Prenume.png`

**Construiți un document word cu numele:** `ExGraf_Nume_Prenume.docx` care să conțină aproximarea procentuală a îndeplinirii obiectivelor:

- Obiectiv 1: 90%
- Obiectiv 2: 70%
- Obiectiv 3: 0%
- ...

**Scrieți la finalul documentului word nota obținută la laborator**

Pentru evaluare vom parcurge pe rând fiecare obiectiv, cu acces la codul sursă (aproximări mult eronate vor duce la pierderea tuturor punctelor).

Trimiteți cele două fișiere până la ora stabilită la adresa stabilită (stabilim la examen cum ii mai bine).

---

## Importanța obiectivelor

- **3** (4 puncte)
- **2, 7, 8** (3 puncte)
- **5, 6** (2.5 puncte)
- **4, 1** (2 puncte)

---

## Web Resources

### Submarine U-99 Type VIIB
- [Wikipedia - German submarine U-99 (1940)](https://en.wikipedia.org/wiki/German_submarine_U-99_(1940))
- [uboat.net - U-99](https://uboat.net/boats/u99.htm)

### L-Systems and Fractals
- [Wikipedia - L-system](https://en.wikipedia.org/wiki/L-system)
- [Medium - L-systems: draw nice fractals and plants](https://medium.com/@hhtun21/l-systems-draw-your-first-fractals-139ed0bfcac2)
- [Rosetta Code - Fractal tree](https://rosettacode.org/wiki/Fractal_tree)

### Gaussian Blur
- [Wikipedia - Gaussian blur](https://en.wikipedia.org/wiki/Gaussian_blur)
- [Stack Overflow - Gaussian Blur Standard Deviation](https://dsp.stackexchange.com/questions/10057/gaussian-blur-standard-deviation-radius-and-kernel-size)
- [Data Carpentry - Image Processing with Python: Blurring Images](https://datacarpentry.github.io/image-processing/06-blurring.html)
