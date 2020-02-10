import { IOffsiteDetector } from "./IOffsiteDetector";
import { AttackDirection } from "./AttackDirection";
import { SoccerFieldInfo } from "./SoccerFieldInfo";
import { PlayerInfo } from "./PlayerInfo";
import { SoccerFieldDataType } from "./SoccerFieldDataType";

export class OffsiteDetector implements IOffsiteDetector {
    constructor() {
    }

    isOffsite(soccerFieldInfo: SoccerFieldInfo): boolean {
        var attackerNearestToGoal = this.getAttackerNearestToGoal(soccerFieldInfo, soccerFieldInfo.attackDirection);
        if (attackerNearestToGoal === undefined)
            return false;

        if (soccerFieldInfo.playerWithBall === undefined || soccerFieldInfo.playerWithBall.type !== SoccerFieldDataType.Attacker
            || soccerFieldInfo.playerWithBall === attackerNearestToGoal)
            return false;

        if (soccerFieldInfo.attackDirection === AttackDirection.LeftToRight) {
            if (attackerNearestToGoal.maxCol < 30)
                return false;
            var defenders = this.getDefendersInFrontOfAttacker(soccerFieldInfo, soccerFieldInfo.attackDirection, attackerNearestToGoal);
            if (defenders.length >= 2)
                return false;
            if (attackerNearestToGoal.maxCol <= soccerFieldInfo.playerWithBall.maxCol)
                return false;
        } else {
            if (attackerNearestToGoal.minCol >= soccerFieldInfo.playerWithBall.minCol)
                return false;
            var defenders = this.getDefendersInFrontOfAttacker(soccerFieldInfo, soccerFieldInfo.attackDirection, attackerNearestToGoal);
            if (defenders.length >= 2)
                return false;
            if (attackerNearestToGoal.minCol >= 30)
                return false;
        }

        return true;
    }

    private getAttackerNearestToGoal(soccerFieldInfo: SoccerFieldInfo, attackDirection: AttackDirection): PlayerInfo | undefined {
        let nearestPlayer: PlayerInfo | undefined = undefined;

        for (let player of soccerFieldInfo.players) {
            if (player.type !== SoccerFieldDataType.Attacker)
                continue;

            if (nearestPlayer === undefined) {
                nearestPlayer = player;
                continue;
            }

            if (attackDirection === AttackDirection.LeftToRight) {
                if (player.maxCol > nearestPlayer.maxCol) {
                    nearestPlayer = player;
                }
            } else {
                if (player.minCol < nearestPlayer.minCol) {
                    nearestPlayer = player;
                }
            }
        }

        return nearestPlayer;
    }

    private getDefendersInFrontOfAttacker(soccerFieldInfo: SoccerFieldInfo, attackDirection: AttackDirection, attacker: PlayerInfo): Array<PlayerInfo> {
        let defenders = new Array<PlayerInfo>();

        for (let player of soccerFieldInfo.players) {
            if (player.type !== SoccerFieldDataType.Defender)
                continue;

            if (attackDirection === AttackDirection.LeftToRight) {
                if (player.maxCol >= attacker.maxCol) {
                    defenders.push(player);
                }
            } else {
                if (player.minCol <= attacker.minCol) {
                    defenders.push(player);
                }
            }
        }

        return defenders;
    }
}