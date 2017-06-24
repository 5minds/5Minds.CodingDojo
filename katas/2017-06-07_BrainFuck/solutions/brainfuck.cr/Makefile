
.PHONY: spec

spec: update
	crystal spec

release:
	crystal build --release src/bin.cr -o bin/brainfuck

update:
	shards check || shards update
