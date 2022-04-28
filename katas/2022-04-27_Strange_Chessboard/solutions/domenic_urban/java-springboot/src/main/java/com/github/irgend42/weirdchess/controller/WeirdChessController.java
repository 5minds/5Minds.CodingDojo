package com.github.irgend42.weirdchess.controller;

import com.github.irgend42.weirdchess.service.WeirdChessService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RequestMapping
@RestController
@RequiredArgsConstructor
public class WeirdChessController {
    private final WeirdChessService chessService;

    @GetMapping("calculateFieldSizes")
    ResponseEntity<Integer[]> calculateFieldSizes(@RequestParam List<Integer> cs, @RequestParam List<Integer> rs){
        return ResponseEntity.ok(chessService.calculatePane(cs, rs));
    }
}
