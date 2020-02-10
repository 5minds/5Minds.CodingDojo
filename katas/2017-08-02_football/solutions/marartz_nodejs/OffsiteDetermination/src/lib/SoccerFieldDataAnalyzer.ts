import { ISoccerFieldDataAnalyzer } from "./ISoccerFieldDataAnalyzer";
import { SoccerFieldInfo } from "./SoccerFieldInfo";
import { SoccerFieldDataType } from "./SoccerFieldDataType";
import { AttackDirection } from "./AttackDirection";
import { PlayerInfo } from "./PlayerInfo";
import { SoccerFieldData } from "./SoccerFieldData";

export class SoccerFieldDataAnalyzer implements ISoccerFieldDataAnalyzer {
    constructor() {
    }

    analyze(soccerFieldData: SoccerFieldData, attackDirection: AttackDirection): SoccerFieldInfo {
        let soccerFieldInfo = new SoccerFieldInfo(attackDirection);

        let mapping: Array<Array<PlayerInfo>> = new Array<Array<PlayerInfo>>(60);
        for (let col = 0; col < 60; col++) {
            mapping[col] = new Array<PlayerInfo>(45);
        }

        for (let col = 0; col < 60; col++) {
            for (let row = 0; row < 45; row++) {
                let val = soccerFieldData.getData(col, row);
                switch (val) {
                    case SoccerFieldDataType.Attacker:
                    case SoccerFieldDataType.Defender:
                        this.processPlayer(soccerFieldInfo, mapping, col, row, val);
                        break;
                    case SoccerFieldDataType.Ball:
                        let player = this.processBall(mapping, col, row);
                        soccerFieldInfo.playerWithBall = player;
                        break;
                    case SoccerFieldDataType.Goal:
                    case SoccerFieldDataType.Empty:
                        break;
                    default:
                        throw "unexpected soccer field data type";
                }
            }
        }



        return soccerFieldInfo;
    }

    private processPlayer(soccerFieldInfo: SoccerFieldInfo, mapping: Array<Array<PlayerInfo>>, col: number, row: number, type: SoccerFieldDataType): PlayerInfo {
        let player: PlayerInfo | undefined = this.findPlayer(mapping, col, row, type);

        if (player === undefined) {
            player = new PlayerInfo(type);
            soccerFieldInfo.players.push(player);
        }

        player.extend(col, row);
        mapping[col][row] = player;

        return player;
    }

    private processBall(mapping: Array<Array<PlayerInfo>>, col: number, row: number) {
        let player: PlayerInfo | undefined = this.findPlayer(mapping, col, row, SoccerFieldDataType.Attacker);

        if (player === undefined) {
            return;
        }

        player.extend(col, row);
        mapping[col][row] = player;

        return player;
    }

    private findPlayer(mapping: Array<Array<PlayerInfo>>, col: number, row: number, type: SoccerFieldDataType) {
        let foundPlayer: PlayerInfo | undefined = undefined;

        if (col === 0) {
            if (row > 0) {
                foundPlayer = mapping[col][row - 1];
                if (foundPlayer !== undefined && foundPlayer.type === type)
                    return foundPlayer;
            }
        } else {
            if (row === 0) {
                foundPlayer = mapping[col - 1][row];
                if (foundPlayer !== undefined && foundPlayer.type === type)
                    return foundPlayer;

                foundPlayer = mapping[col - 1][row + 1];
                if (foundPlayer !== undefined && foundPlayer.type === type)
                    return foundPlayer;
            } else {
                foundPlayer = mapping[col - 1][row - 1];
                if (foundPlayer !== undefined && foundPlayer.type === type)
                    return foundPlayer;

                foundPlayer = mapping[col - 1][row];
                if (foundPlayer !== undefined && foundPlayer.type === type)
                    return foundPlayer;

                foundPlayer = mapping[col - 1][row + 1];
                if (foundPlayer !== undefined && foundPlayer.type === type)
                    return foundPlayer;

                foundPlayer = mapping[col][row - 1];
                if (foundPlayer !== undefined && foundPlayer.type === type)
                    return foundPlayer;
            }
        }

        return undefined;
    }
}