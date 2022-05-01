SELECT SUM(g.DepositAmount - h.DepositAmount) 
  FROM WizzardDeposits h
  JOIN WizzardDeposits g ON h.Id = g.Id + 1
  