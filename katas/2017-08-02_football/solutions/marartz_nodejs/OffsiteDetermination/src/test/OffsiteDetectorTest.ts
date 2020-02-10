import { describe } from "mocha";
import { expect } from "chai";
import { OffsiteDetector } from "../lib/OffsiteDetector";
import { AttackDirection } from "../lib/AttackDirection";
import { SoccerFieldInfo } from "../lib/SoccerFieldInfo";
import { PlayerInfo } from "../lib/PlayerInfo";
import { SoccerFieldDataType } from "../lib/SoccerFieldDataType";

describe('OffsiteDetector Tests', function () {
    it('no players on field should return no offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.false;
    });

    it('only defenders on field should return no offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const defender1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        defender1.extend(53, 30);
        fieldInfo.players.push(defender1);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        defender2.extend(55, 20);
        fieldInfo.players.push(defender2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.false;
    });

    it('attacker potentially in offsite but have no ball should return no offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(30, 3);
        fieldInfo.players.push(attacker1);

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(40, 20);
        fieldInfo.players.push(defender1);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(42, 30);
        fieldInfo.players.push(defender2);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(50, 30);
        fieldInfo.players.push(attacker2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.false;
    });

    it('attackers potentially in offsite but defender has ball should return no offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(30, 3);
        fieldInfo.players.push(attacker1);

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(40, 20);
        fieldInfo.players.push(defender1);
        fieldInfo.playerWithBall = defender1;

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(42, 30);
        fieldInfo.players.push(defender2);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(50, 30);
        fieldInfo.players.push(attacker2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.false;
    });

    it('attacker far in offsite no defenders in front should return offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(30, 3);
        fieldInfo.players.push(attacker1);
        fieldInfo.playerWithBall = attacker1;

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(40, 20);
        fieldInfo.players.push(defender1);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(42, 30);
        fieldInfo.players.push(defender2);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(50, 30);
        fieldInfo.players.push(attacker2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.true;
    });

    it('attacker far in offsite one defender in front should return offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(30, 3);
        fieldInfo.players.push(attacker1);
        fieldInfo.playerWithBall = attacker1;

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(40, 20);
        fieldInfo.players.push(defender1);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(50, 30);
        fieldInfo.players.push(attacker2);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(59, 23);
        fieldInfo.players.push(defender2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.true;
    });

    it('attacker in front of defender but two defenders in front of attacker should return no offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(30, 3);
        fieldInfo.players.push(attacker1);
        fieldInfo.playerWithBall = attacker1;

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(40, 20);
        fieldInfo.players.push(defender1);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(50, 30);
        fieldInfo.players.push(attacker2);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(59, 23);
        fieldInfo.players.push(defender2);

        const defender3 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender3.extend(59, 30);
        fieldInfo.players.push(defender3);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.false;
    });

    it('two attackers in front of all defenders and left attacker passes to right attacker should return offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(40, 16);
        fieldInfo.players.push(defender1);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(40, 23);
        fieldInfo.players.push(defender2);

        const defender3 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender3.extend(40, 30);
        fieldInfo.players.push(defender3);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(50, 3);
        fieldInfo.players.push(attacker1);
        fieldInfo.playerWithBall = attacker1;

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(55, 30);
        fieldInfo.players.push(attacker2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.true;
    });

    it('two attackers in front of all defenders and right attacker passes to left attacker should return no offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(40, 16);
        fieldInfo.players.push(defender1);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(40, 23);
        fieldInfo.players.push(defender2);

        const defender3 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender3.extend(40, 30);
        fieldInfo.players.push(defender3);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(50, 3);
        fieldInfo.players.push(attacker1);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(55, 30);
        fieldInfo.players.push(attacker2);
        fieldInfo.playerWithBall = attacker2;

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.false;
    });

    it('attacker in front of all defenders but in own half should return no offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(5, 3);
        fieldInfo.players.push(attacker1);
        fieldInfo.playerWithBall = attacker1;

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(10, 16);
        fieldInfo.players.push(defender1);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(10, 23);
        fieldInfo.players.push(defender2);

        const defender3 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender3.extend(10, 30);
        fieldInfo.players.push(defender3);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(29, 30);
        fieldInfo.players.push(attacker2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.false;
    });

    it('attacker in front of all defenders but just in other half should return offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(5, 3);
        fieldInfo.players.push(attacker1);
        fieldInfo.playerWithBall = attacker1;

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(10, 16);
        fieldInfo.players.push(defender1);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(10, 23);
        fieldInfo.players.push(defender2);

        const defender3 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender3.extend(10, 30);
        fieldInfo.players.push(defender3);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(30, 30);
        fieldInfo.players.push(attacker2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.true;
    });

    it('attacker on same line as one defender and one defender in goal should return no offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(35, 3);
        fieldInfo.players.push(attacker1);
        fieldInfo.playerWithBall = attacker1;

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(50, 16);
        fieldInfo.players.push(defender1);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(50, 30);
        fieldInfo.players.push(attacker2);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(59, 23);
        fieldInfo.players.push(defender2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.false;
    });

    it('attacker on same line as one defender should return offsite', function () {
        const fieldInfo = new SoccerFieldInfo(AttackDirection.LeftToRight);

        const attacker1 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker1.extend(35, 3);
        fieldInfo.players.push(attacker1);
        fieldInfo.playerWithBall = attacker1;

        const defender1 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender1.extend(36, 16);
        fieldInfo.players.push(defender1);

        const defender2 = new PlayerInfo(SoccerFieldDataType.Defender);
        defender2.extend(50, 23);
        fieldInfo.players.push(defender2);

        const attacker2 = new PlayerInfo(SoccerFieldDataType.Attacker);
        attacker2.extend(50, 30);
        fieldInfo.players.push(attacker2);

        const detector = new OffsiteDetector();
        const result = detector.isOffsite(fieldInfo);

        expect(result).to.be.true;
    });
});