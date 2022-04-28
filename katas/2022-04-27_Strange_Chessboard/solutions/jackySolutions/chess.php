<?php
$cs = [ 3, 1, 2, 7, 1 ];
$rs = [ 1, 8, 4, 5, 2 ];
$chess = new chess($cs, $rs);
echo json_encode($chess->chessBoardArea());

$cs = [3, 1, 2, 7, 1, 11, 12, 3, 8, 1];
$rs = [1, 8, 4, 5, 2, 21, 5, 2, 2, 17];
$chess = new chess($cs, $rs);
echo json_encode($chess->chessBoardArea());

$cs = [3];
$rs = [2];
$chess = new chess($cs, $rs);
echo json_encode($chess->chessBoardArea());

class chess {
    private $cs;
    private $rs;
    private $isBlack;

   public function __construct(array $cs, array $rs){
        $this->cs = $cs;
        $this->rs = $rs;
        $this->isBlack = 0;
    }

   public function chessBoardArea():array {
       $chessFieldArea = [0,0];
        foreach($this->cs as $activeCs){
            foreach($this->rs as $activeRs){
                $chessFieldArea[($this->isBlack++)%2] += $this->fieldSize($activeCs, $activeRs);
            }
            
            if((count($this->cs)%2) == 0){
                $this->isBlack++;
            }
        }
        return $chessFieldArea;
    }

    private function fieldSize(int $activeCs, int $activeRs){
        return $activeCs * $activeRs;
    }

    function test(){

    }

}

?>