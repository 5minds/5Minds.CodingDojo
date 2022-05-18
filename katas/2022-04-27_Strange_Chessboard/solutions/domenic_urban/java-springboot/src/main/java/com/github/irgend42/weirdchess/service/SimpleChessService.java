package com.github.irgend42.weirdchess.service;

import lombok.val;

import java.util.List;

public class SimpleChessService implements WeirdChessService{
    @Override
    public Long[] calculatePane(List<Integer> cs, List<Integer> rs) {
        Long[] result = new Long[]{0L,0L};
        for (int i = 0; i < cs.size(); i++) {
            for (int j = 0; j < rs.size(); j++) {
                result[(i+j)%2] += (long) cs.get(i) * rs.get(j);
            }
        }
        return result;
    }
}
