package com.github.irgend42.weirdchess.service;

import lombok.val;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class SimpleChessService implements WeirdChessService{
    @Override
    public Integer[] calculatePane(List<Integer> cs, List<Integer> rs) {
        val result = new Integer[]{0,0};
        for (int i = 0; i < cs.size(); i++) {
            for (int j = 0; j < rs.size(); j++) {
                result[(i+j)%2] += cs.get(i) * rs.get(j);
            }
        }
        return result;
    }
}
