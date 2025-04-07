# Import required libraries
import numpy as np
import matplotlib.pyplot as plt
from sklearn import datasets
from sklearn.tree import DecisionTreeClassifier, plot_tree
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score

# Load the IRIS dataset
iris = datasets.load_iris()

# Extract features, labels, feature names, and label names
features = iris.data
labels = iris.target
feature_names = iris.feature_names
label_names = iris.target_names

# Explore the dataset using shape property
print("Features shape:", features.shape)
print("Labels shape:", labels.shape)

# Split the dataset into training and testing sets
X_train, X_test, y_train, y_test = train_test_split(features, labels, test_size=0.3, random_state=42)

# Instantiate the Decision Tree Classifier model
model = DecisionTreeClassifier()

# Train the model
model.fit(X_train, y_train)

# Predict using the model
predictions = model.predict(X_test)

# Print actual vs predicted
print("Actual labels:   ", y_test)
print("Predicted labels:", predictions)

# Evaluate accuracy
accuracy = accuracy_score(y_test, predictions)
print("Model Accuracy:", accuracy)

# Visualize the decision tree
plt.figure(figsize=(12, 8))
plot_tree(model, feature_names=feature_names, class_names=label_names, filled=True)
plt.show()
