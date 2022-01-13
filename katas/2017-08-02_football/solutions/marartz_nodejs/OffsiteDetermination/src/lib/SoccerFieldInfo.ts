import { AttackDirection } from "./AttackDirection";
import { PlayerInfo } from "./PlayerInfo";

export class SoccerFieldInfo {
    private _attackDirection: AttackDirection;
    private _players: Array<PlayerInfo>;
    private _playerWithBall: PlayerInfo | undefined;

    constructor(attackDirection: AttackDirection) {
        this._attackDirection = attackDirection;
        this._players = new Array<PlayerInfo>();
        this._playerWithBall = undefined;
    }

    get attackDirection(): AttackDirection {
        return this._attackDirection;
    }

    get players(): Array<PlayerInfo> {
        return this._players;
    }

    get playerWithBall(): PlayerInfo | undefined {
        return this._playerWithBall;
    }

    set playerWithBall(val: PlayerInfo | undefined) {
        this._playerWithBall = val;
    }
}