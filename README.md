# PRG2782 — Superhero Database (Windows Forms + Git)

A Windows Forms app that manages superhero records in `superheroes.txt`, supports **Add, View, Update, Delete**, and generates a **Summary** saved to `summary.txt`. 
Rank & threat level are calculated from the exam score:

- **S (81–100)** → *Finals Week*
- **A (61–80)** → *Midterm Madness*
- **B (41–60)** → *Group Project Gone Wrong*
- **C (0–40)** → *Pop Quiz*

## Requirements this implements
- Add, View, Update, Delete heroes (with validation & file I/O).
- Display heroes in a DataGridView.
- Summary on form and in `summary.txt`.
- Clear error messages for bad inputs and file I/O issues.
- Git-ready folder structure.

## How to run
1. Make sure you have **.NET 6 SDK** and **Visual Studio 2022** or **Visual Studio Code + C# Dev Kit** installed.
2. Open `SuperheroDB.sln` in Visual Studio **or** open `SuperheroDB/SuperheroDB.csproj` directly.
3. Press **F5** to run.

> If your lab uses .NET Framework 4.8, you can retarget by editing the `.csproj` to use `<TargetFramework>net48</TargetFramework>` and reopen the project.

## What to test (maps to rubric)
- **Add**: Valid hero; duplicate ID; invalid score (<0 or >100).
- **View**: After add/delete the grid refreshes.
- **Update**: Select a row, modify fields, change score to trigger rank recalculation.
- **Delete**: Select a row or enter ID -> Delete (with confirmation).
- **Summary**: Check labels update and `summary.txt` created with totals, averages, and rank counts.



# After each feature
git add .
git commit -m "Implement Add hero with validation and rank/threat calculation"
git commit -m "Implement View + grid refresh"
git commit -m "Implement Update functionality (recalculate rank & threat)"
git commit -m "Implement Delete with confirmation + refresh"
git commit -m "Implement Summary + summary.txt output"
git push
```

## File format
CSV with header:
```
HeroId,Name,Age,Superpower,ExamScore,Rank,ThreatLevel
```

## Notes
- Fields with commas are not supported; keep names/powers simple (as per project brief expectations).
- `superheroes.txt` is created automatically on first run.
- `summary.txt` is overwritten whenever you click **Generate Summary**.
