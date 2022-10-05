namespace RecursionFun.LevenshteinDistance.FSharpLib

module LevenshteinDistanceService =
    let lastchar (s:string) = s.Substring(s.Length-1, 1)
    let lastchar_substring (s:string) len = s.Substring(len-1, 1)

    let levdist (sa:string) (sb:string) = 
        let rec levdist_cont (sa:string) (sb:string) alen blen cont =
            match alen, blen with
                | -1, -1 -> levdist_cont sa sb sa.Length sb.Length cont
                |  0,  0 -> cont 0
                |  _,  0 -> cont alen
                |  0,  _ -> cont blen
                |  _ -> 
                    levdist_cont sa sb (alen - 1) (blen    ) (fun l1 ->
                    levdist_cont sa sb (alen    ) (blen - 1) (fun l2 ->
                    levdist_cont sa sb (alen - 1) (blen - 1) (fun l3 -> 
                        let d = if (lastchar_substring sa alen) = (lastchar_substring sb blen) then 0 else 1
                        cont (min (l1 + 1) (min (l2 + 1) (l3 + d)))
                        )))

        levdist_cont sa sb -1 -1 (fun x -> x)
        