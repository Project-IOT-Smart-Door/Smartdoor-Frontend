# Smartdoor-Frontend

Aplikasi desktop **Project IOT Smart Door** — pintu pintar berbasis kartu RFID (tugas kelompok mata kuliah Internet of Things, Kelompok 4). Berisi aplikasi WPF C# dan script installer.

> Bagian dari organisasi [Project-IOT-Smart-Door](https://github.com/Project-IOT-Smart-Door):
> - [Smartdoor-Backend](https://github.com/Project-IOT-Smart-Door/Smartdoor-Backend) — class library backend + database
> - [Smartdoor-Frontend](https://github.com/Project-IOT-Smart-Door/Smartdoor-Frontend) (repo ini)
> - [Smartdoor-Firmware](https://github.com/Project-IOT-Smart-Door/Smartdoor-Firmware) — kode Arduino

## Cara kerja singkat
1. Kartu RFID di-tap pada modul RC522.
2. Arduino Uno mengirim UID ke komputer lewat Serial (`UID:xxxx`).
3. Aplikasi desktop ini mencocokkan UID dengan database (lewat backend) dan membalas `OPEN` atau `DENY`.
4. Setiap tap tercatat di tabel `LOG_AKSES`.

## Isi repository
```
SmartDoor.Frontend.slnx         # Solution .NET
src/SmartDoor.App/
├── App.xaml / MainWindow.xaml  # Entry point WPF
├── Themes/                     # Tema Terang & Gelap (Custom, Gelap, Terang)
├── ViewModels/MainViewModel.cs # Logika MVVM
└── Views/
    ├── LoginView.xaml          # Login admin/pengguna
    ├── AdminView.xaml          # Panel admin
    └── UserView.xaml           # Panel pengguna
installer/
└── setup.iss                   # Script Inno Setup (build Setup.exe via Releases)
```

## Menjalankan
```bash
dotnet run --project src/SmartDoor.App
```
Dibutuhkan [.NET SDK](https://dotnet.microsoft.com/download) dan koneksi Serial ke Arduino Uno.

## Membangun Installer
Script `installer/setup.iss` dibangun dengan [Inno Setup](https://jrsoftware.org/isinfo.php). Hasil `Setup.exe` diunggah lewat fitur **Releases**, bukan dimasukkan ke kode.

## Perangkat
Arduino Uno, modul RFID RC522, buzzer, LED merah/hijau, relay 1 channel, solenoid door lock (catu daya terpisah + dioda flyback).

## Tim
| Nama | Peran |
|---|---|
| Bayu Putra Setia Eka Premana | Project Manager & Embedded Developer |
| Aria Julianto Wasnita | Hardware / IoT Engineer |
| Ibnu Fatur Rahman | Frontend Developer |
| Muhamad Falzen Ridwan | Backend Developer & Database Admin |
| Suripto | DevOps / Deployment Engineer |
| Wahyu Pahrudin | QA Tester & Technical Writer |

## Aturan kerja
- Jangan commit hasil build (`*.exe`, `bin/`, `obj/`) atau password. File `.gitignore` sudah menanganinya.
- Setup.exe diunggah lewat fitur **Releases**, bukan dimasukkan ke kode.
- Setiap anggota bekerja di branch sendiri, lalu membuat Pull Request ke `main`.
- Pesan commit singkat dan jelas, misalnya `frontend: perbaiki login view`.
