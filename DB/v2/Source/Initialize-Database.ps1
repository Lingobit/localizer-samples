# Runs in 32-bit Windows PowerShell because the legacy sample uses the Jet driver.
param([Parameter(Mandatory=$true)][string]$DatabasePath,[Parameter(Mandatory=$true)][string]$RowsPath)
$ErrorActionPreference='Stop'
$connection=New-Object System.Data.OleDb.OleDbConnection ('Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+$DatabasePath)
$connection.Open()
$transaction=$connection.BeginTransaction()
try {
    $delete=$connection.CreateCommand();$delete.Transaction=$transaction
    $delete.CommandText='DELETE FROM Books_single_row';[void]$delete.ExecuteNonQuery()
    $rows=Get-Content -LiteralPath $RowsPath -Raw -Encoding UTF8|ConvertFrom-Json
    foreach($row in $rows){
        $insert=$connection.CreateCommand();$insert.Transaction=$transaction
        $insert.CommandText='INSERT INTO Books_single_row (ID,Title_en,Author_en) VALUES (?,?,?)'
        [void]$insert.Parameters.AddWithValue('ID',[int]$row.id)
        [void]$insert.Parameters.AddWithValue('Title_en',[string]$row.text)
        [void]$insert.Parameters.AddWithValue('Author_en','Sample Team')
        [void]$insert.ExecuteNonQuery()
    }
    $transaction.Commit()
} catch {$transaction.Rollback();throw} finally {$connection.Close()}
