import { useNavigation } from "@react-navigation/native";
import React from "react";
import { View, Text, StyleSheet, TouchableOpacity } from "react-native";

const CategoryCard = ({ title, progress, color, targetScreen }) => {
  const navigation = useNavigation();

  return (
    <TouchableOpacity
      style={[styles.container, { backgroundColor: color }]}
      onPress={() => navigation.navigate(targetScreen)}
    >
      <Text style={styles.title}>{title}</Text>
      <View style={styles.progressContainer}>
        <Text style={styles.progressText}>Progress</Text>
        <Text style={styles.progressPercentage}>{progress}%</Text>
      </View>
    </TouchableOpacity>
  );
};

const styles = StyleSheet.create({
  container: {
    borderRadius: 10,
    padding: 24,
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

export default CategoryCard;
