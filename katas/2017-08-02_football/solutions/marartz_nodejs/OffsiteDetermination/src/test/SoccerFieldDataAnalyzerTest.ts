import { describe } from "mocha";
import { expect, assert } from "chai";
import { SoccerFieldData } from "../lib/SoccerFieldData";
import { SoccerFieldDataAnalyzer } from "../lib/SoccerFieldDataAnalyzer";
import { AttackDirection } from "../lib/AttackDirection";
import { SoccerFieldDataType } from "../lib/SoccerFieldDataType";

describe('SoccerFieldDataAnalyzer Tests', function () {
    it('analyzing an empty field should have no players', function () {
        const fieldData = new SoccerFieldData();

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(0);
        expect(result.playerWithBall).to.equal(undefined);
    });

    it('minimal defender should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        fieldData.setData(1, 1, SoccerFieldDataType.Defender);

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(1);
        const player = result.players[0];
        expect(player.type).to.equal(SoccerFieldDataType.Defender);
        expect(player.minCol).to.equal(1);
        expect(player.maxCol).to.equal(1);
        expect(player.minRow).to.equal(1);
        expect(player.maxRow).to.equal(1);
        expect(result.playerWithBall).to.equal(undefined);
    });

    it('maximal defender should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        for (let col = 0; col < 3; col++) {
            for (let row = 0; row < 3; row++) {
                fieldData.setData(col, row, SoccerFieldDataType.Defender);
            }
        }

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(1);
        const player = result.players[0];
        expect(player.type).to.equal(SoccerFieldDataType.Defender);
        expect(player.minCol).to.equal(0);
        expect(player.maxCol).to.equal(2);
        expect(player.minRow).to.equal(0);
        expect(player.maxRow).to.equal(2);
        expect(result.playerWithBall).to.equal(undefined);
    });

    it('defender pattern 1 should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        fieldData.setData(1, 0, SoccerFieldDataType.Defender);
        fieldData.setData(1, 1, SoccerFieldDataType.Defender);
        fieldData.setData(2, 2, SoccerFieldDataType.Defender);

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(1);
        const player = result.players[0];
        expect(player.type).to.equal(SoccerFieldDataType.Defender);
        expect(player.minCol).to.equal(1);
        expect(player.maxCol).to.equal(2);
        expect(player.minRow).to.equal(0);
        expect(player.maxRow).to.equal(2);
        expect(result.playerWithBall).to.equal(undefined);
    });

    it('defender pattern 2 should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        fieldData.setData(0, 0, SoccerFieldDataType.Defender);
        fieldData.setData(0, 1, SoccerFieldDataType.Defender);
        fieldData.setData(1, 1, SoccerFieldDataType.Defender);
        fieldData.setData(1, 2, SoccerFieldDataType.Defender);
        fieldData.setData(2, 2, SoccerFieldDataType.Defender);

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(1);
        const player = result.players[0];
        expect(player.type).to.equal(SoccerFieldDataType.Defender);
        expect(player.minCol).to.equal(0);
        expect(player.maxCol).to.equal(2);
        expect(player.minRow).to.equal(0);
        expect(player.maxRow).to.equal(2);
        expect(result.playerWithBall).to.equal(undefined);
    });

    it('minimal attacker should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        fieldData.setData(1, 1, SoccerFieldDataType.Attacker);

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(1);
        const player = result.players[0];
        expect(player.type).to.equal(SoccerFieldDataType.Attacker);
        expect(player.minCol).to.equal(1);
        expect(player.maxCol).to.equal(1);
        expect(player.minRow).to.equal(1);
        expect(player.maxRow).to.equal(1);
        expect(result.playerWithBall).to.equal(undefined);
    });

    it('maximal attacker should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        for (let col = 0; col < 3; col++) {
            for (let row = 0; row < 3; row++) {
                fieldData.setData(col, row, SoccerFieldDataType.Attacker);
            }
        }

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(1);
        const player = result.players[0];
        expect(player.type).to.equal(SoccerFieldDataType.Attacker);
        expect(player.minCol).to.equal(0);
        expect(player.maxCol).to.equal(2);
        expect(player.minRow).to.equal(0);
        expect(player.maxRow).to.equal(2);
        expect(result.playerWithBall).to.equal(undefined);
    });

    it('attacker pattern 1 should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        fieldData.setData(1, 0, SoccerFieldDataType.Attacker);
        fieldData.setData(1, 1, SoccerFieldDataType.Attacker);
        fieldData.setData(2, 2, SoccerFieldDataType.Attacker);

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(1);
        const player = result.players[0];
        expect(player.type).to.equal(SoccerFieldDataType.Attacker);
        expect(player.minCol).to.equal(1);
        expect(player.maxCol).to.equal(2);
        expect(player.minRow).to.equal(0);
        expect(player.maxRow).to.equal(2);
        expect(result.playerWithBall).to.equal(undefined);
    });

    it('attacker pattern 2 should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        fieldData.setData(0, 0, SoccerFieldDataType.Attacker);
        fieldData.setData(0, 1, SoccerFieldDataType.Attacker);
        fieldData.setData(1, 1, SoccerFieldDataType.Attacker);
        fieldData.setData(1, 2, SoccerFieldDataType.Attacker);
        fieldData.setData(2, 2, SoccerFieldDataType.Attacker);

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(1);
        const player = result.players[0];
        expect(player.type).to.equal(SoccerFieldDataType.Attacker);
        expect(player.minCol).to.equal(0);
        expect(player.maxCol).to.equal(2);
        expect(player.minRow).to.equal(0);
        expect(player.maxRow).to.equal(2);
        expect(result.playerWithBall).to.equal(undefined);
    });

    it('attacker with ball should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        fieldData.setData(1, 0, SoccerFieldDataType.Attacker);
        fieldData.setData(0, 1, SoccerFieldDataType.Attacker);
        fieldData.setData(1, 1, SoccerFieldDataType.Attacker);
        fieldData.setData(2, 1, SoccerFieldDataType.Ball);
        fieldData.setData(2, 2, SoccerFieldDataType.Attacker);

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(1);
        const player = result.players[0];
        expect(player.type).to.equal(SoccerFieldDataType.Attacker);
        expect(player.minCol).to.equal(0);
        expect(player.maxCol).to.equal(2);
        expect(player.minRow).to.equal(0);
        expect(player.maxRow).to.equal(2);
        expect(result.playerWithBall).to.deep.equal(player);
    });

    it('duel should be detected properly', function () {
        const fieldData = new SoccerFieldData();
        fieldData.setData(1, 0, SoccerFieldDataType.Attacker);
        fieldData.setData(0, 1, SoccerFieldDataType.Defender);
        fieldData.setData(1, 1, SoccerFieldDataType.Attacker);
        fieldData.setData(2, 1, SoccerFieldDataType.Attacker);
        fieldData.setData(1, 2, SoccerFieldDataType.Defender);

        const analyzer = new SoccerFieldDataAnalyzer();
        const result = analyzer.analyze(fieldData, AttackDirection.LeftToRight);

        expect(result.attackDirection).to.equal(AttackDirection.LeftToRight);
        expect(result.players).to.have.lengthOf(2);
        const defender = result.players[0];
        expect(defender.type).to.equal(SoccerFieldDataType.Defender);
        expect(defender.minCol).to.equal(0);
        expect(defender.maxCol).to.equal(1);
        expect(defender.minRow).to.equal(1);
        expect(defender.maxRow).to.equal(2);
        const attacker = result.players[1];
        expect(attacker.type).to.equal(SoccerFieldDataType.Attacker);
        expect(attacker.minCol).to.equal(1);
        expect(attacker.maxCol).to.equal(2);
        expect(attacker.minRow).to.equal(0);
        expect(attacker.maxRow).to.equal(1);
        expect(result.playerWithBall).to.equal(undefined);
    });
});