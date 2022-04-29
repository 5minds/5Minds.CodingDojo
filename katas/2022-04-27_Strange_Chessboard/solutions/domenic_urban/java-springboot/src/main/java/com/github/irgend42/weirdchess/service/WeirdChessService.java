package com.github.irgend42.weirdchess.service;

import java.util.List;

public interface WeirdChessService {
    Long[] calculatePane(List<Integer> cs, List<Integer> ws);
}
