fn main() {
    let cs: &[i32] = &[3,1,2,7,1];
    let rs: &[i32] = &[1,8,4,5,2];

    let white_black_tuple = get_white_and_black_square(cs, rs);

    println!("{:?}", white_black_tuple);

    let cs1: &[i32] = &[3,1,2,7,1,11,12,3,8,1];
    let rs1: &[i32] = &[1,8,4,5,2,21,5,2,2,17];

    let white_black_tuple1 = get_white_and_black_square(cs1, rs1);
    
    println!("{:?}", white_black_tuple1);

    let cs2: &[i32] = &[3];
    let rs2: &[i32] = &[2];

    let white_black_tuple2 = get_white_and_black_square(cs2, rs2);
    
    println!("{:?}", white_black_tuple2);
}

fn get_white_and_black_square(cs: &[i32], rs: &[i32]) -> (i32, i32) {
    let mut white_square = 0;
    let mut black_square = 0;

    for column in 0..cs.len() {
        for row in 0..rs.len() {
            if is_even(column) {
                if is_even(row) {
                    white_square = white_square + cs[column] * rs[row];
                }
                else {
                    black_square = black_square + cs[column] * rs[row];
                }
            }
            else {
                if is_even(row) {
                    black_square = black_square + cs[column] * rs[row];
                }
                else {
                    white_square = white_square + cs[column] * rs[row];
                }
            }
        }
    }
    
    (white_square, black_square)
}

fn is_even(value: usize) -> bool {
    value%2 == 0
}
