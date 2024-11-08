# DotaHeroDashboard

DotaHeroDashboard is a web application for tracking and analyzing Dota 2 heroes using data from the OpenDota API. It provides hero suggestions and metadata analysis for Dota 2 players.

## Prerequisites

- [.NET SDK 7.0](https://dotnet.microsoft.com/download/dotnet/7.0) or later
- [Git](https://git-scm.com/) for cloning the repository
- An internet connection for retrieving data from the OpenDota API

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/FarelW/Dota2Dashboard.git
cd Dota2Dashboard
```

## Running The Web Application

1. Navigate to the main directory
```bash
cd DotaHeroDashboard
```

2. Restore the required packages:
```bash
dotnet restore
```

3. Run Application
```bash
dotnet run
```

## Running the Unit Tests

1. Navigate to the main directory
```bash
cd DotaHeroDashboard.Tests
```

2. Restore the required packages:
```bash
dotnet restore
```

3. Run Application
```bash
dotnet test
```