import numpy as np


inputs = [[[1,2,3],[4,5,6]]]
weights = [[7,10],[8,11],[9,12]]



output = np.dot(inputs,weights)
print(output)