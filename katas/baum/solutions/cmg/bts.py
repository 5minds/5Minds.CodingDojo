#!/usr/bin/env python
# -*- coding: utf-8 -*-

class Element(object):
    def __init__(self, left=None, right=None, content=None):
        self.left = left
        self.right = right
        self.content = content


def find_root_element(list_of_content):
    element_index = int(len(list_of_content)/2)
    choosen_element = list_of_content[element_index]
    return choosen_element, element_index


def split_list(content_list, where):
    left = content_list[:where]
    right = content_list[where+1:]
    return left, right


def construct_tree(content_list):
    if not content_list:
        return None

    center_content, index = find_root_element(content_list)
    left, right = split_list(content_list, index)

    if len(content_list) == 1:
        return Element(None, None, center_content)
    else:
        node = Element(
            construct_tree(left),
            construct_tree(right),
            center_content
        )
        return node


def print_tree(baum, level = 0, direction="root"):
    if baum == None:
        return
    level = level + 1
    print("{} {} {}".format(level, baum.content, direction))
    print_tree(baum.left, level, "left")
    print_tree(baum.right, level, "right")


def main():
    element_content = [7, 79, 20, 60, 11, 15, 40, 30]
    sorted_element_content = sorted(element_content)

    print("Sorted Elements: {}".format(sorted_element_content))

    tree = construct_tree(sorted_element_content)

    print_tree(tree)


if __name__ == "__main__":
    main()
