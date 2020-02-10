import * as fs from 'fs';
import * as util from 'util';
import { SoccerFieldDataType } from './SoccerFieldDataType';

export class SoccerFieldData {
    private data: Array<Array<SoccerFieldDataType>>

    constructor() {
        this.data = new Array<Array<SoccerFieldDataType>>(60);
        for (let col = 0; col < 60; col++) {
            this.data[col] = new Array<SoccerFieldDataType>(45);
            for (let row = 0; row < 45; row++) {
                if ((col == 0 || col == 59) && row >= 20 && row <= 24) {
                    this.data[col][row] = SoccerFieldDataType.Goal;
                } else {
                    this.data[col][row] = SoccerFieldDataType.Empty;
                }
            }
        }
    }

    static async ReadFrom(filePath: string): Promise<SoccerFieldData> {
        const readFile = util.promisify(fs.readFile);
        let buffer = await readFile(filePath);

        let soccerField = new SoccerFieldData();

        let curCol = 0;
        let curRow = 0;

        for (let i = 0; i < buffer.length; i++) {
            let curVal = buffer[i];

            switch (curVal) {
                case 111: // o = empty
                    soccerField.setData(curCol, curRow, SoccerFieldDataType.Empty);
                    curCol++;
                    break;
                case 120: // x = defender
                    soccerField.setData(curCol, curRow, SoccerFieldDataType.Defender);
                    curCol++;
                    break;
                case 43: // + = attacker
                    soccerField.setData(curCol, curRow, SoccerFieldDataType.Attacker);
                    curCol++;
                    break;
                case 64: // @ = ball
                    soccerField.setData(curCol, curRow, SoccerFieldDataType.Ball);
                    curCol++;
                    break;
                case 124: // | = midline
                    if (curCol == 0 || curCol == 59) {
                        if (curRow < 20 || curRow > 24)
                            throw "soccer field data is not valid: goal is not where is supposed to be";
                        soccerField.setData(curCol, curRow, SoccerFieldDataType.Goal);
                        curCol++;
                    } else {
                        if (curCol !== 30)
                            throw "soccer field data is not valid: midline is not where is supposed to be";
                        // ignore
                    }
                    break;
                case 13: // CR
                    // ignore
                    break;
                case 10: // LF
                    if (curCol !== 60)
                        throw "soccer field data is not valid: width is not 60";
                    curCol = 0;
                    curRow++;
                    break;
                default:
                    throw "soccer field data is not valid: unexpected data: " + curVal;
            }
        }

        if (curRow !== 45)
            throw "soccer field data is not valid: height is not 45";

        return soccerField;
    }

    getData(col: number, row: number): SoccerFieldDataType {
        if (!this.checkColRange(col))
            throw "column is out of allowed range [0; 59]: " + col;
        if (!this.checkRowRange(row))
            throw "row is out of allowed range [0; 44]" + row;

        let colArray = this.data[col];
        return colArray[row];
    }

    setData(col: number, row: number, val: SoccerFieldDataType) {
        if (!this.checkColRange(col))
            throw "column is out of allowed range [0; 59]: " + col;
        if (!this.checkRowRange(row))
            throw "row is out of allowed range [0; 44]" + row;

        let colArray = this.data[col];
        colArray[row] = val;
    }

    private checkColRange(col: number): boolean {
        return 0 <= col && col < 60;
    }

    private checkRowRange(row: number): boolean {
        return 0 <= row && row < 45;
    }
}