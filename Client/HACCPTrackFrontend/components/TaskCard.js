import React from "react";
import { View, Text, StyleSheet } from "react-native";

const TaskCard = ({ title, progress, color }) => {
  return (
    <View style={[styles.container, { backgroundColor: color }]}>
      <Text style={styles.title}>{title}</Text>
      <View style={styles.progressContainer}>
        <Text style={styles.progressText}>Progress</Text>
        <Text style={styles.progressPercentage}>{progress}%</Text>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    borderRadius: 10,
    padding: 16,
    marginVertical: 8,
    flex: 1,
  },
  title: {
    color: "white",
    marginBottom: 8,
  },
  progressContainer: {
    flexDirection: "row",
    justifyContent: "space-between",
  },
  progressText: {
    color: "white",
  },
  progressPercentage: {
    color: "white",
  },
});

export default TaskCard;
