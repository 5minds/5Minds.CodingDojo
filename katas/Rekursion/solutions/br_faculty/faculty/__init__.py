def faculty(n):
    if n > 1:
        return n * faculty(n-1)
    else:
        return 1
