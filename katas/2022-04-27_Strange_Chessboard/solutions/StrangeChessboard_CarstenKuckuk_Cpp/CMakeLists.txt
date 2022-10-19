cmake_minimum_required(VERSION 2.8.12)

project(Schachbrettkata)

INCLUDE_DIRECTORIES(
	libs/gtest-1.7.0/include
	libs/gtest-1.7.0
)

SET(GTEST_AMALGAMATION_FILES
	libs/gtest-1.7.0/src/gtest-all.cc
)

set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

ADD_EXECUTABLE(SchachbrettTool
schachbretttool.cpp
schachbrett.hpp
schachbrett.cpp)

ADD_EXECUTABLE(SchachbrettTest
schachbretttests.cpp
schachbrett.hpp
schachbrett.cpp
${GTEST_AMALGAMATION_FILES}
)

