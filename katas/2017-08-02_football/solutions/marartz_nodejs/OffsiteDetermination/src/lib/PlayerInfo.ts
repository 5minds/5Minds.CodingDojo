import { Position } from "./Position";
import { SoccerFieldDataType } from "./SoccerFieldDataType";

export class PlayerInfo {
    private _type: SoccerFieldDataType;
    private _minCol: number;
    private _maxCol: number;
    private _minRow: number;
    private _maxRow: number;

    constructor(type: SoccerFieldDataType) {
        this._type = type;
        this._minCol = Number.MAX_VALUE;
        this._maxCol = Number.MIN_VALUE;
        this._minRow = Number.MAX_VALUE;
        this._maxRow = Number.MIN_VALUE;
    }

    get type(): SoccerFieldDataType {
        return this._type;
    }

    get minCol(): number {
        return this._minCol;
    }

    get maxCol(): number {
        return this._maxCol;
    }

    get minRow(): number {
        return this._minRow;
    }

    get maxRow(): number {
        return this._maxRow;
    }

    extend(col: number, row: number) {
        if (this._minCol === undefined || col < this._minCol) {
            this._minCol = col;
        }
        if (this._maxCol === undefined || col > this._maxCol) {
            this._maxCol = col;
        }
        if (this._minRow === undefined || row < this._minRow) {
            this._minRow = row;
        }
        if (this._maxRow === undefined || row > this._maxRow) {
            this._maxRow = row;
        }
    }

    //get hasBall(): boolean {
    //    return this._hasBall;
    //}

    //get hasLeft(): boolean {
    //    for (let i = 0; i < 3; i++) {
    //        let pos = 0 * 3 + i;
    //        if (this._data[pos] != SoccerFieldDataType.Empty)
    //            return true;
    //    }
    //    return false;
    //}

    //get hasRight(): boolean {
    //    for (let i = 0; i < 3; i++) {
    //        let pos = 2 * 3 + i;
    //        if (this._data[pos] != SoccerFieldDataType.Empty)
    //            return true;
    //    }
    //    return false;
    //}

    //get hasTop(): boolean {
    //    for (let i = 0; i < 3; i++) {
    //        let pos = i * 3 + 0;
    //        if (this._data[pos] != SoccerFieldDataType.Empty)
    //            return true;
    //    }
    //    return false;
    //}

    //get hasBottom(): boolean {
    //    for (let i = 0; i < 3; i++) {
    //        let pos = i * 3 + 2;
    //        if (this._data[pos] != SoccerFieldDataType.Empty)
    //            return true;
    //    }
    //    return false;
    //}
}
