export class Position {
    private _col: number;
    private _row: number;

    constructor(col: number, row: number) {
        this._col = col;
        this._row = row;
    }

    get col(): number {
        return this._col;
    }

    get row(): number {
        return this._row;
    }
}
