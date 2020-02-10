import { SoccerFieldData } from "./lib/SoccerFieldData";
import { SoccerFieldDataAnalyzer } from "./lib/SoccerFieldDataAnalyzer";
import { OffsiteDetector } from "./lib/OffsiteDetector";
import { AttackDirection } from "./lib/AttackDirection";
import { IOffsiteDetector } from "./lib/IOffsiteDetector";
import { ISoccerFieldDataAnalyzer } from "./lib/ISoccerFieldDataAnalyzer";

async function checkFile(fileName: string, analyzer: ISoccerFieldDataAnalyzer, detector: IOffsiteDetector) {
    let soccerFieldData = await SoccerFieldData.ReadFrom(fileName);
    let soccerFieldInfo = analyzer.analyze(soccerFieldData, AttackDirection.LeftToRight);
    let isOffsite = detector.isOffsite(soccerFieldInfo);
    console.log("check of file '" + fileName + "': " + (isOffsite ? "offsite" : "no offsite"));
}

async function main() {
    try {
        let analyzer = new SoccerFieldDataAnalyzer();
        let detector = new OffsiteDetector();

        await checkFile("./examples/situation_1.txt", analyzer, detector);
        await checkFile("./examples/situation_2.txt", analyzer, detector);
        await checkFile("./examples/situation_3.txt", analyzer, detector);
        await checkFile("./examples/situation_4.txt", analyzer, detector);
        await checkFile("./examples/situation_5.txt", analyzer, detector);

        console.log("... finished");
    } catch (e) {
        console.error("unexpected error: " + e);
    }
}

main();