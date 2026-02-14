SELECT        HistoryTBL.id, personalTBL.name, personalTBL.LastName, personalTBL.number, bookTBL.book, HistoryTBL.bookNum
FROM            personalTBL INNER JOIN
                         HistoryTBL ON personalTBL.id = HistoryTBL.IDpersonal INNER JOIN
                         bookTBL ON HistoryTBL.IDbook = bookTBL.id