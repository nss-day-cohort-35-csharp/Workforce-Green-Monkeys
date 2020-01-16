SELECT c.Id, c.Make, c.Model, c.PurchaseDate, c.DecomissionDate
                                            FROM Computer c
                                            LEFT JOIN Employee e ON c.Id = e.ComputerId
                                            WHERE e.ComputerId Is Null AND  c.Id = 1