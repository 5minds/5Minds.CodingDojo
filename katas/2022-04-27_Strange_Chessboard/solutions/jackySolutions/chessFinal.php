<?php
$cs = [ 3, 1, 2, 7, 1 ];
$rs = [ 1, 8, 4, 5, 2 ];
echo json_encode(chess::chessBoardArea($cs, $rs));

$cs = [3, 1, 2, 7, 1, 11, 12, 3, 8, 1];
$rs = [1, 8, 4, 5, 2, 21, 5, 2, 2, 17];
echo json_encode(chess::chessBoardArea($cs, $rs));

$cs = [3];
$rs = [2];
echo json_encode(chess::chessBoardArea($cs, $rs));

class chess {

   public static function chessBoardArea(array $cs, array $rs):array {
       $chessBoardArea = [0,0];
       $isBlack = 0;
        foreach($cs as $activeCs){
            foreach($rs as $activeRs){
                $chessBoardArea[($isBlack++)%2] += $activeCs * $activeRs;
            }
            if((count($cs)%2) == 0){
                $isBlack++;
            }
        }
        return $chessBoardArea;
    }
}

?>