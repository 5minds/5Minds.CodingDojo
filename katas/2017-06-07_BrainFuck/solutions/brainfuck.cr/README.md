# brainfuck

Brainfuck in Crystal

## Installation

Install [Crystal 0.22.0](https://crystal-lang.org/) and GNU make.

    shards update

## Run

    make release
    bin/brainfuck samples/*.bf
    cat samples/hello_world_no_loop.bf | bin/brainfuck

## Test

    make spec
